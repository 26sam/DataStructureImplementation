using DataStructureImplementation.Enumeration;

namespace DataStructureImplementation
{
    internal class Person : IComparable<Person>
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }


        public int CompareTo(Person other)
        {
            int result = 0;
            switch ((SortingParameters)App.SortingParameter) 
            {
                case SortingParameters.firstName:
                    result = FirstName.CompareTo(other.FirstName);
                    break;

                case SortingParameters.lastName:
                    result = LastName.CompareTo(other.LastName);
                    break;

                case SortingParameters.city:
                    result = City.CompareTo(other.City);
                    break;

                case SortingParameters.state:
                    result = State.CompareTo(other.State);
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            return result;
        }
        public override string ToString()
        {
            string tempString = $"{Id,-10} {FirstName,-15} {LastName,-15} {Age,-8} {State,-15} {City,-15} {ContactNumber,-12}";
            return tempString;
        }
    }
}
