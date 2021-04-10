using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BiografAPI.Web.Models;

namespace BiografAPI.Web.Data
{
    public class DatabaseProcedures
    {
        #region Genre
        public bool CreateGenre(int id, string type)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var genre = new Genre()
                    {
                        Id = id,
                        Type = type,
                    };
                    context.Genres.Add(genre);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Genre>> GetGenres()
        {
            try
            {
                List<Genre> genres = new List<Genre>();

                await using (var context = new BiografContext())
                {
                    foreach (var item in context.Genres)
                    {
                        Genre model = new Genre()
                        {
                            Id = item.Id,
                            Type = item.Type
                        };
                        genres.Add(model);
                    }
                }

                return genres;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Genre GetGenre(int id)
        {
            try
            {
                Genre genre = new Genre();

                using (var context = new BiografContext())
                {
                    var item = context.Genres.Find(id);

                    genre.Id = item.Id;
                    genre.Type = item.Type;
                }

                return genre;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateGenre(int id, string newTypeValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var genre = context.Genres.Find(id);
                    genre.Type = newTypeValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGenre(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Genres.Remove(context.Genres.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Movie
        public bool CreateMovie(int id, string title, int genreId, string director, string description, int durationMin)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var movie = new Movie()
                    {
                        Id = id,
                        Title = title,
                        GenreId = context.Genres.Find(genreId).Id,
                        Director = director,
                        Description = description,
                        DurationMin = durationMin,
                        Genre = context.Genres.Find(genreId)
                    };

                    context.Movies.Add(movie);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Movie> GetMovieList()
        {
            try
            {
                List<Movie> movies = new List<Movie>();

                using (var context = new BiografContext())
                {
                    foreach (var movie in context.Movies)
                    {
                        Movie movieModel = new Movie()
                        {
                            Id = movie.Id,
                            Title = movie.Title,
                            GenreId = movie.GenreId,
                            Director = movie.Director,
                            Description = movie.Description,
                            DurationMin = movie.DurationMin
                        };

                        using (var secondaryContext = new BiografContext())
                        {
                            movieModel.Genre = secondaryContext.Genres.Find(movie.GenreId);
                        }

                        movies.Add(movieModel);
                    }
                }

                return movies;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Movie GetMovie(int id)
        {
            try
            {
                Movie movieModel;

                using (var context = new BiografContext())
                {
                    var movie = context.Movies.Find(id);
                    movieModel = new Movie()
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        GenreId = movie.GenreId,
                        Director = movie.Director,
                        Description = movie.Description,
                        DurationMin = movie.DurationMin
                    };

                    using (var secondaryContext = new BiografContext())
                    {
                        movieModel.Genre = secondaryContext.Genres.Find(movie.GenreId);
                    }
                }

                return movieModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateMovie(int id, string newTitleValue, int? newGenreIdValue, string newDirectorValue, string newDescriptionValue, int? newDurationMin)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var movie = context.Movies.Find(id);
                    if (!string.IsNullOrEmpty(newTitleValue))
                        movie.Title = newTitleValue;
                    if (newGenreIdValue != null)
                        movie.GenreId = newGenreIdValue;
                    if (!string.IsNullOrEmpty(newDirectorValue))
                        movie.Director = newDirectorValue;
                    if (!string.IsNullOrEmpty(newDescriptionValue))
                        movie.Description = newDescriptionValue;
                    if (newDurationMin != null)
                        movie.DurationMin = newDurationMin;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMovie(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Movies.Remove(context.Movies.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Screening
        public bool CreateScreening(int id, int movieId, int auditoriumId, DateTime? screeningStart)
        {
            try
            {
                using (var context = new BiografContext())
                {

                    var screening = new Screening()
                    {
                        Id = id,
                        MovieId = context.Movies.Find(movieId).Id,
                        AuditoriumId = context.Auditoria.Find(auditoriumId).Id,
                        ScreeningStart = screeningStart
                    };
                    context.Screenings.Add(screening);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Screening> GetScreeningList()
        {
            try
            {
                List<Screening> screenings = new List<Screening>();

                using (var context = new BiografContext())
                {
                    foreach (var screening in context.Screenings)
                    {
                        Screening screeningModel = new Screening()
                        {
                            Id = screening.Id,
                            MovieId = screening.MovieId,
                            AuditoriumId = screening.AuditoriumId,
                            ScreeningStart = screening.ScreeningStart
                        };

                        using (var secondaryContext = new BiografContext())
                        {
                            screeningModel.Movie = secondaryContext.Movies.Find(screening.MovieId);
                        }

                        using (var secondaryContext = new BiografContext())
                        {
                            screeningModel.Movie.Genre = secondaryContext.Genres.Find(screeningModel.Movie.GenreId);
                        }

                        using (var secondaryContext = new BiografContext())
                        {
                            screeningModel.Auditorium = secondaryContext.Auditoria.Find(screening.AuditoriumId);
                        }

                        screenings.Add(screeningModel);
                    }
                }

                return screenings;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Screening GetScreening(int id)
        {
            try
            {
                Screening screeningModel;

                using (var context = new BiografContext())
                {
                    var screening = context.Screenings.Find(id);
                    screeningModel = new Screening()
                    {
                        Id = screening.Id,
                        MovieId = screening.MovieId,
                        AuditoriumId = screening.AuditoriumId,
                        Movie = GetMovie(context.Movies.Find(screening.MovieId).Id),
                        Auditorium = GetAuditorium(context.Auditoria.Find(screening.AuditoriumId).Id),
                        ScreeningStart = screening.ScreeningStart
                    };
                }

                return screeningModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateScreening(int id, int? newMovieIdValue, int? newAuditoriumIdValue, DateTime? newScreeningStartValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var screening = context.Screenings.Find(id);
                    if (newMovieIdValue != null)
                        screening.MovieId = newMovieIdValue;
                    if (newAuditoriumIdValue != null)
                        screening.AuditoriumId = newAuditoriumIdValue;
                    if (newScreeningStartValue != null)
                        screening.ScreeningStart = newScreeningStartValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteScreening(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Screenings.Remove(context.Screenings.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Auditorium
        public bool CreateAuditorium(int id, string name, int seatsNumber)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var auditorium = new Auditorium()
                    {
                        Id = id,
                        Name = name,
                        SeatsNumber = seatsNumber
                    };
                    context.Auditoria.Add(auditorium);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Auditorium> GetAuditoriumList()
        {
            try
            {
                List<Auditorium> auditoriumList = new List<Auditorium>();

                using (var context = new BiografContext())
                {
                    foreach (var auditorium in context.Auditoria)
                    {
                        Auditorium auditoriumModel = new Auditorium()
                        {
                            Id = auditorium.Id,
                            Name = auditorium.Name,
                            SeatsNumber = auditorium.SeatsNumber
                        };

                        auditoriumList.Add(auditoriumModel);
                    }
                }

                return auditoriumList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Auditorium GetAuditorium(int id)
        {
            try
            {
                Auditorium auditoriumModel;

                using (var context = new BiografContext())
                {
                    var auditorium = context.Auditoria.Find(id);
                    auditoriumModel = new Auditorium()
                    {
                        Id = auditorium.Id,
                        Name = auditorium.Name,
                        SeatsNumber = auditorium.SeatsNumber
                    };
                }

                return auditoriumModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateAuditorium(int id, string newNameValue, int? newSeatsNumberValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var auditorium = context.Auditoria.Find(id);
                    if (newNameValue != null)
                        auditorium.Name = newNameValue;
                    if (newSeatsNumberValue != null)
                        auditorium.SeatsNumber = newSeatsNumberValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAuditorium(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Auditoria.Remove(context.Auditoria.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Seat
        public bool CreateSeat(int id, int? row, int? number, int? auditoriumId)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var seat = new Seat()
                    {
                        Id = id,
                        Row = row,
                        Number = number,
                        AuditoriumId = auditoriumId
                    };
                    context.Seats.Add(seat);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Seat> GetSeatList()
        {
            try
            {
                List<Seat> seatList = new List<Seat>();

                using (var context = new BiografContext())
                {
                    foreach (var seat in context.Seats)
                    {
                        Seat seatModel = new Seat()
                        {
                            Id = seat.Id,
                            Row = seat.Row,
                            Number = seat.Number,
                            AuditoriumId = seat.AuditoriumId,
                            //Auditorium = context.Auditoria.Find(seat.AuditoriumId)
                        };

                        using (var secondaryContext = new BiografContext())
                        {
                            seatModel.Auditorium = secondaryContext.Auditoria.Find(seat.AuditoriumId);
                        }

                        seatList.Add(seatModel);
                    }
                }

                return seatList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Seat GetSeat(int id)
        {
            try
            {
                Seat seatModel;

                using (var context = new BiografContext())
                {
                    var seat = context.Seats.Find(id);
                    seatModel = new Seat()
                    {
                        Id = seat.Id,
                        Row = seat.Row,
                        Number = seat.Number,
                        AuditoriumId = seat.AuditoriumId,
                        Auditorium = context.Auditoria.Find(seat.AuditoriumId)
                    };
                }

                return seatModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateSeat(int id, int? newRowValue, int? newNumberValue, int? newAuditoriumIdValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var seat = context.Seats.Find(id);
                    if (newRowValue != null)
                        seat.Row = newRowValue;
                    if (newNumberValue != null)
                        seat.Number = newNumberValue;
                    if (newAuditoriumIdValue != null)
                        seat.AuditoriumId = newAuditoriumIdValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSeat(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Seats.Remove(context.Seats.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region SeatReserved
        public bool CreateSeatReserved(int id, int? seatId, int? reservationId, int? screeningId)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var seatReserved = new SeatReserved()
                    {
                        Id = id,
                        SeatId = seatId,
                        ReservationId = reservationId,
                        ScreeningId = screeningId
                    };
                    context.SeatReserveds.Add(seatReserved);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SeatReserved> GetSeatReservedList()
        {
            try
            {
                List<SeatReserved> seatReservedList = new List<SeatReserved>();

                using (var context = new BiografContext())
                {
                    foreach (var seatReserved in context.SeatReserveds)
                    {
                        SeatReserved seatReservedModel = new SeatReserved()
                        {
                            Id = seatReserved.Id,
                            SeatId = seatReserved.SeatId,
                            ReservationId = seatReserved.ReservationId,
                            ScreeningId = seatReserved.ScreeningId,
                            //Reservation = context.Reservations.Find(seatReserved.ReservationId),
                            //Screening = context.Screenings.Find(seatReserved.ScreeningId)
                        };

                        using (var secondaryContext = new BiografContext())
                        {
                            seatReservedModel.Reservation = secondaryContext.Reservations.Find(seatReserved.ReservationId);
                        }

                        using (var tertiaryContext = new BiografContext())
                        {
                            seatReservedModel.Screening = tertiaryContext.Screenings.Find(seatReserved.ScreeningId);
                        }

                        seatReservedList.Add(seatReservedModel);
                    }
                }

                return seatReservedList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SeatReserved GetSeatReserved(int id)
        {
            try
            {
                SeatReserved seatReservedModel;

                using (var context = new BiografContext())
                {
                    var seatReserved = context.SeatReserveds.Find(id);
                    seatReservedModel = new SeatReserved()
                    {
                        Id = seatReserved.Id,
                        SeatId = seatReserved.SeatId,
                        ReservationId = seatReserved.ReservationId,
                        ScreeningId = seatReserved.ScreeningId,
                        Reservation = context.Reservations.Find(seatReserved.ReservationId),
                        Screening = context.Screenings.Find(seatReserved.ScreeningId)
                    };
                }

                return seatReservedModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateSeatReserved(int id, int? newSeatIdValue, int? newReservationIdValue, int? newScreeningIdValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var seatReserved = context.SeatReserveds.Find(id);
                    if (newSeatIdValue != null)
                        seatReserved.SeatId = newSeatIdValue;
                    if (newReservationIdValue != null)
                        seatReserved.ReservationId = newReservationIdValue;
                    if (newScreeningIdValue != null)
                        seatReserved.ScreeningId = newScreeningIdValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteSeatReserved(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.SeatReserveds.Remove(context.SeatReserveds.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Reservation
        public bool CreateReservation(int id, int? screeningId, int? employeeReservedId, int? reservationTypeId, string reservationContactName, bool reserved, int? employeePaidId, bool paid, bool active)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var reservation = new Reservation()
                    {
                        Id = id,
                        ScreeningId = screeningId,
                        EmployeeReservedId = employeeReservedId,
                        ReservationTypeId = reservationTypeId,
                        ReservationContactName = reservationContactName,
                        Reserved = reserved,
                        EmployeePaidId = employeePaidId,
                        Paid = paid,
                        Active = active
                    };
                    context.Reservations.Add(reservation);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Reservation> GetReservationList()
        {
            try
            {
                List<Reservation> reservationList = new List<Reservation>();

                using (var context = new BiografContext())
                {
                    foreach (var reservation in context.Reservations)
                    {
                        Reservation reservationModel = new Reservation()
                        {
                            Id = reservation.Id,
                            ScreeningId = reservation.ScreeningId,
                            EmployeeReservedId = reservation.EmployeeReservedId,
                            ReservationTypeId = reservation.ReservationTypeId,
                            ReservationContactName = reservation.ReservationContactName,
                            Reserved = reservation.Reserved,
                            EmployeePaidId = reservation.EmployeePaidId,
                            Paid = reservation.Paid,
                            Active = reservation.Active
                        };

                        //Swagger kan ikke vise al den sammenkoblet information, derfor skærer jeg af.

                        //using (var secondaryContext = new BiografContext())
                        //{
                        //    reservationModel.Screening = secondaryContext.Screenings.Find(reservation.ScreeningId);
                        //    reservationModel.Screening.Auditorium = secondaryContext.Auditoria.Find(reservationModel.Screening.AuditoriumId);
                        //    reservationModel.Screening.Movie = secondaryContext.Movies.Find(reservationModel.Screening.MovieId);                                                       
                        //}

                        //using (var secondaryContext = new BiografContext())
                        //{
                        //    reservationModel.EmployeeReserved = secondaryContext.Employees.Find(reservationModel.EmployeeReservedId);
                        //    reservationModel.EmployeePaid = secondaryContext.Employees.Find(reservationModel.EmployeePaidId);
                        //}

                        //using (var secondaryContext = new BiografContext())
                        //{
                        //    reservationModel.ReservationType = secondaryContext.ReservationTypes.Find(reservationModel.ReservationTypeId);
                        //}

                        reservationList.Add(reservationModel);
                    }
                }

                return reservationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Reservation GetReservation(int id)
        {
            try
            {
                Reservation reservationModel;

                using (var context = new BiografContext())
                {
                    var reservation = context.Reservations.Find(id);
                    reservationModel = new Reservation()
                    {
                        Id = reservation.Id,
                        ScreeningId = reservation.ScreeningId,
                        EmployeeReservedId = reservation.EmployeeReservedId,
                        ReservationTypeId = reservation.ReservationTypeId,
                        ReservationContactName = reservation.ReservationContactName,
                        Reserved = reservation.Reserved,
                        EmployeePaidId = reservation.EmployeePaidId,
                        Paid = reservation.Paid,
                        Active = reservation.Active
                    };

                    using (var secondaryContext = new BiografContext())
                    {
                        reservationModel.Screening = secondaryContext.Screenings.Find(reservation.ScreeningId);
                        reservationModel.Screening.Auditorium = secondaryContext.Auditoria.Find(reservationModel.Screening.AuditoriumId);
                        reservationModel.Screening.Movie = secondaryContext.Movies.Find(reservationModel.Screening.MovieId);
                    }

                    using (var secondaryContext = new BiografContext())
                    {
                        reservationModel.EmployeeReserved = secondaryContext.Employees.Find(reservationModel.EmployeeReservedId);
                        reservationModel.EmployeePaid = secondaryContext.Employees.Find(reservationModel.EmployeePaidId);
                    }

                    using (var secondaryContext = new BiografContext())
                    {
                        reservationModel.ReservationType = secondaryContext.ReservationTypes.Find(reservationModel.ReservationTypeId);
                    }
                }

                return reservationModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateReservation(int id, int? newScreeningIdValue, int? newEmployeeReservedIdValue, int? newReservationTypeIdValue, string newReservationContactNameValue, bool? newReservedValue, int? newEmployeePaidIdValue, bool? newPaidValue, bool? newActiveValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var reservation = context.Reservations.Find(id);
                    if (newScreeningIdValue != null)
                        reservation.ScreeningId = newScreeningIdValue;
                    if (newEmployeeReservedIdValue != null)
                        reservation.EmployeeReservedId = newEmployeeReservedIdValue;
                    if (newReservationTypeIdValue != null)
                        reservation.ReservationTypeId = newReservationTypeIdValue;
                    if (newReservationContactNameValue != null)
                        reservation.ReservationContactName = newReservationContactNameValue;
                    if (newReservedValue != null)
                        reservation.Reserved = newReservedValue;
                    if (newEmployeePaidIdValue != null)
                        reservation.EmployeePaidId = newEmployeePaidIdValue;
                    if (newPaidValue != null)
                        reservation.Paid = newPaidValue;
                    if (newActiveValue != null)
                        reservation.Active = newActiveValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteReservations(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Reservations.Remove(context.Reservations.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region ReservationType
        public bool CreateReservationType(int id, string type)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var reservationType = new ReservationType()
                    {
                        Id = id,
                        Type = type
                    };
                    context.ReservationTypes.Add(reservationType);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ReservationType> GetReservationTypeList()
        {
            try
            {
                List<ReservationType> reservationTypeList = new List<ReservationType>();

                using (var context = new BiografContext())
                {
                    foreach (var reservationType in context.ReservationTypes)
                    {
                        ReservationType reservationTypeModel = new ReservationType()
                        {
                            Id = reservationType.Id,
                            Type = reservationType.Type
                        };

                        reservationTypeList.Add(reservationType);
                    }
                }

                return reservationTypeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReservationType GetReservationType(int id)
        {
            try
            {
                ReservationType reservationTypeModel;

                using (var context = new BiografContext())
                {
                    var reservationType = context.ReservationTypes.Find(id);
                    reservationTypeModel = new ReservationType()
                    {
                        Id = reservationType.Id,
                        Type = reservationType.Type
                    };
                }

                return reservationTypeModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateReservationType(int id, string newTypeValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var reservationType = context.ReservationTypes.Find(id);
                    if (newTypeValue != null)
                        reservationType.Type = newTypeValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteReservationType(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.ReservationTypes.Remove(context.ReservationTypes.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Employee
        public bool CreateEmployee(int id, string username, string password)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var employee = new Employee()
                    {
                        Id = id,
                        Username = username,
                        Password = password
                    };
                    context.Employees.Add(employee);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Employee> GetEmployeeList()
        {
            try
            {
                List<Employee> employeesList = new List<Employee>();

                using (var context = new BiografContext())
                {
                    foreach (var employee in context.Employees)
                    {
                        Employee employeeModel = new Employee()
                        {
                            Id = employee.Id,
                            Username = employee.Username,
                            Password = employee.Password
                        };

                        employeesList.Add(employeeModel);
                    }
                }

                return employeesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                Employee employeeModel;

                using (var context = new BiografContext())
                {
                    var employee = context.Employees.Find(id);
                    employeeModel = new Employee()
                    {
                        Id = employee.Id,
                        Username = employee.Username,
                        Password = employee.Password
                    };
                }

                return employeeModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Employee GetEmployeeLogin(string username, string password)
        {
            try
            {
                Employee employeeModel = null;

                using (var context = new BiografContext())
                {
                    foreach (var item in context.Employees)
                    {
                        if (item.Username.ToLower() == username.ToLower())
                        {
                            if (item.Password.ToLower() == password.ToLower())
                            {
                                employeeModel = new Employee()
                                {
                                    Id = item.Id,
                                    Username = item.Username,
                                    Password = item.Password
                                };
                            }
                        }
                    }                    
                }

                return employeeModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateEmployee(int id, string newUsernameValue, string newPasswordValue)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    var employee = context.Employees.Find(id);
                    if (newUsernameValue != null)
                        employee.Username = newUsernameValue;
                    if (newPasswordValue != null)
                        employee.Password = newPasswordValue;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                using (var context = new BiografContext())
                {
                    context.Employees.Remove(context.Employees.Find(id));

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}