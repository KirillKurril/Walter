namespace WLWD5.Domain.Entities
{
    public class Computer
    {
        public Processor? Processor { get; set; }
        public Memory? RAM { get; set; }
        public Storage? Drive { get; set; }

        public Computer() { }

        public Computer(Processor? processor = null, Memory? rAM = null, Storage? drive = null)
        {
            Processor = processor == null ? new Processor() : processor;
            RAM = rAM == null ? new Memory() : rAM;
            Drive = drive == null ? new Storage() : drive;
        }

        public override string ToString()
        {
            return $"\nProcessor: {Processor}" +
                $"\nRAM: {RAM}" +
                $"\nDrive: {Drive}\n";
        }
    }
}
