namespace Consola.dto
{
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static Pet[] GetCats()
        {
            Pet[] cats = 
            {  
                 new Pet { Name="Barley",    Age=8 },
                 new Pet { Name="Boots",     Age=4 },
                 new Pet { Name="Whiskers",  Age=1 } 
            };
            return cats;
        }

        public static Pet[] GetDogs()
        {
            Pet[] dogs = 
            { 
                new Pet { Name="Bounder",   Age=3 },
                new Pet { Name="Snoopy",    Age=14 },
                new Pet { Name="Fido",      Age=9 } 
            };
            return dogs;
        }
    }
}
