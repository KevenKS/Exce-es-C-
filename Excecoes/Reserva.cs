using System;
using Excecoes.Exceptions;

namespace Excecoes
{
    class Reserva
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reserva() { }

        public Reserva(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                // throw é usado para lançar uma nova instancia, neste caso da exceção 'DomainException' (exceção criada e personalizada por nós) e também apos lançada, ela 'cortara' o metodo, encerrando. 
                // Como esta exceção é relacionada a entidade 'reserva', então ela é relacionada ao dominio do sistema (Domain)
                // Dominio(Domain) é o termo tecnico utilizado para referencia o negocio do sistema. Neste caso é reserva/hoteis. Por isso o nome da exceção.
                throw new DomainException("Check-out date must be after check-in date");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if (checkin < now || checkout < now)
            {
                // throw é usado para lançar uma nova instancia, neste caso da exceção 'DomainException' (exceção criada e personalizada por nós) e também apos lançada, ela 'cortara' o metodo, encerrando. 
                // Como esta exceção é relacionada a entidade 'reserva', então ela é relacionada ao dominio do sistema (Domain)
                // Dominio(Domain) é o termo tecnico utilizado para referencia o negocio do sistema. Neste caso é reserva/hoteis. Por isso o nome da exceção.
                throw new DomainException("Reservation dates for update must be future dates");
            }
            else if (checkout <= checkin)
            {
                // throw é usado para lançar uma nova instancia, neste caso da exceção 'DomainException' (exceção criada e personalizada por nós) e também apos lançada, ela 'cortara' o metodo, encerrando. 
                // Como esta exceção é relacionada a entidade 'reserva', então ela é relacionada ao dominio do sistema (Domain)
                // Dominio(Domain) é o termo tecnico utilizado para referencia o negocio do sistema. Neste caso é reserva/hoteis. Por isso o nome da exceção.
                throw new DomainException("Check-out date must be after check-in date");
            }

            CheckIn = checkin;
            CheckOut = checkout;
        }

        public override string ToString()
        {
            return "Room " + RoomNumber + ", check-in: " + CheckIn.ToString("dd/MM/yyyy") + ", check-out: " + CheckOut.ToString("dd/MM/yyyy") + ", " + Duration() + " noites";
        }


    }
}
