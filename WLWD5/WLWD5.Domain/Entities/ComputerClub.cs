using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WLWD5.Domain.Entities
{
    public class ComputerClubWrapper
    {
        public string Name { get; set; }
        public List<Computer> ComputerList { get; set; }

        public ComputerClubWrapper() { }
        public ComputerClubWrapper(ComputerClub computerClub)
            => (Name, ComputerList) = (computerClub.Name, computerClub.ComputerList);
        public ComputerClubWrapper(string name, List<Computer> computerList)
            => (Name, ComputerList) = (name, computerList);
    }
    public class ComputerClub : IEnumerable<Computer>
    {
        public List<Computer> ComputerList { get; set; }
        public string Name { get; set; }
        public ComputerClub(List<Computer> computerList, string name = "nameless")
            => (ComputerList, Current, Name) = (computerList, computerList?.FirstOrDefault(), name);

        public Computer? Current { get; private set; }

        public IEnumerator<Computer> GetEnumerator()
        {
            return new ComputerEnumerator(ComputerList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string output = $"\nName: {Name}\n";
            if (ComputerList.Any())
                foreach (var computer in ComputerList)
                {
                    output += computer.ToString();
                }
            else
                output += "I'm sorry, but the computers haven't arrived yet\n";
            return output;
        }
        private class ComputerEnumerator : IEnumerator<Computer>
        {
            private readonly List<Computer>? computerList;
            private int currentIndex = -1;

            public ComputerEnumerator(List<Computer>? computerList)
            {
                this.computerList = computerList;
            }

            public Computer Current
            {
                get
                {
                    if (currentIndex >= 0 && currentIndex < computerList?.Count)
                    {
                        return computerList[currentIndex];
                    }
                    throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (computerList != null && currentIndex < computerList.Count - 1)
                {
                    currentIndex++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose() { }
        }
    }
}