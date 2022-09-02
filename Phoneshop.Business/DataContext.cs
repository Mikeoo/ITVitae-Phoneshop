using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Entities;

namespace Phoneshop.Business
{
    public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductPerOrder> ProductsPerOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(x => x.ProductsPerOrder).WithOne();
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });


            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 1,
                Name = "Apple"
            },
            new Brand
            {
                Id = 2,
                Name = "OnePlus"
            },
            new Brand
            {
                Id = 3,
                Name = "Motorola"
            });

            modelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 1,
                Type = "iPhone 12 Pro 128GB Zwart",
                Description = "The iPhone 12 Pro is part of the Fall 2020 iPhone 12 series. It comes with the impressive specs we've come to expect from Apple, including a gorgeous 6.1-inch screen, excellent camera and blazing-fast hardware. It also looks great with its matte and angular finish. With support for 5G Internet, you'll have access to the fastest network and be ready for the future. All in all, Apple has delivered another great device! Super powerful processor To drive everything, the iPhone 12 Pro is equipped with the A14 processor, which was developed by Apple itself. This makes it work optimally with the software, and it can run the heaviest apps effortlessly. Multitasking is also not an issue. Three cameras on the back Like its predecessor, this smartphone is a true winner when it comes to photos. It has three lenses that all have their own function, like zooming in or capturing a wider angle. Thanks to the night mode, you can also shoot beautiful pictures in low light. Another great feature is portrait mode, which lets you take professional-looking photos. Animojis lets you create a fun digital avatar to send to your friends. Face ID is an accurate face-recognition feature that lets only you unlock your phone! LiDAR scanner The iPhone 12 Pro features a LiDAR scanner. This is a depth sensor that measures how long it takes for light to be reflected from an object, in order to measure the distance to that object. This technology was previously found in the iPad Pro and is used in Artificial Reality. Premium design The design of the iPhone 12 Pro is a striking change from the iPhone 11 Pro. It has a more angular design, something familiar from older iPhones like the iPhone 5. The back has a cool matte finish, giving it a stylish look. 5G support The 12-series iPhones are the first iPhones that can connect to the new 5G network. This is becoming increasingly available in the Netherlands, so you have access to this super fast internet! So stream your favourite films and series even faster. Magnetic accessories The iPhone 12 Pro has a new feature called MagSafe. This was the brand name of magnetic chargers for MacBooks and now it covers magnetic accessories. This means you can quickly and easily attach MagSafe accessories to your iPhone, such as wireless chargers, cases, and card holders. Box Contents A smartphone often comes with a charging adapter and earbuds for listening to music. Apple has decided not to do that anymore, with the idea that it saves waste and packaging. However, this does mean that you will have to buy these separately if you don't already have them. You do get a Lightning to USB-C cable, though.",
                Price = 1028,
                Stock = 17,
                BrandId = 1
            },
            new Phone
            {
                Id = 2,
                Type = "Nord 2 128GB Grijs",
                Description = "Deze Oneplus Nord 2 128GB Grijs is de opvolger van de populaire Nord. Hij biedt goede specificaties zoals een 90Hz AMOLED-scherm en sneller processor voor een schappelijke prijs. Deze grijze variant beschikt over 128GB aan opslaggeheugen en 8GB werkgeheugen. De Nord 2 wordt aangestuurd door de snelle MediaTek Dimensity 1200-processor die het ook mogelijk maakt om gebruik te maken van het 5G-netwerk. Daarnaast heeft deze Nord 2 van Oneplus drie goede camera's aan de achterkant en ondersteunt hij snelladen tot 65Watt. Genoeg rekenkracht dankzij snelle processor De Dimensity 1200-chip van MediaTek zorgt voor snelle prestaties op een energie-efficiÃ«nte manier, hierdoor is hij geschikt voor vrijwel alle apps en zelfs voor zwaardere games! Doordat hij slim met zijn energieverbruik om gaat verbruikt hij niet onnodig veel stroom bij het multitasken en draaien van zware apps. Vloeiend AMOLED-scherm van 6.43 inch Het scherm van de Nord 2 maakt gebruik van de AMOLED-techniek waardoor de kleuren van het scherm af spatten! Naast het betere contrast verbruikt deze techniek ook een stuk minder stroom dan LCD-schermen. Vooral bij zwarte beelden zie je goed dat de kleuren mooier en dieper worden weergegeven. Mooie plaatjes met 50-megapixelcamera Aan de achterkant van deze Oneplus Nord 2 128GB Grijs vinden we een cameramodule met drie lenzen en een LED-flitser. De hoofdlens heeft 50 megapixels en ondersteunt optische beeldstabilisatie. Hiermee maak je scherpe foto's en bestaan je video's niet meer uit schokkende beelden! Om een breed landschap of een grote groep mensen vast te leggen gebruik je de 8MP-ultragroothoeklens. Deze heeft een breed gezichtsveld zodat alles er helemaal op past! De monochrome lens helpt bij portretfoto's en aan de voorkant vinden we een 32MP-selfiecamera. Stroom voor de hele dag De batterij van deze grijze Oneplus Nord 2 heeft een capaciteit van 4500mAh, een stukje groter dan zijn voorganger. Dankzij deze verbeterede batterij gebruik je deze telefoon de hele dag zonder hem op te hoeven laden! Dit gaat overigens ook razendsnel dankzij de meegeleverde 65Watt-snellader.",
                Price = 439,
                Stock = 4,
                BrandId = 2
            },
            new Phone
            {
                Id = 3,
                Type = "Moto G20 Blauw",
                Description = "De Motorola Moto G20 is een budgetsmartphone die zeer geschikt is voor mensen die niet op zoek zijn naar de nieuwste snufjes, maar wel gewoon bereikbaar willen zijn. Dankzij de grote batterij heb je met deze telefoon een betrouwbaar apparaat met genoeg stroom. Verder is hij uitgerust met een 6.5-inchdisplay waar veel op past in Ã©Ã©n keer en een viertal cameraâ€™s op de achterkant. Je hebt 64GB aan opslagcapaciteit wat genoeg is voor de meeste mensen. Daarnaast is er ruimte voor een geheugenkaartje. Groot en vloeiend scherm Het display heeft een afmeting van 6.5 inch en is daarmee lekker groot. Dit is handig als je graag boeken of andere tekst leest, want zo past er meer in beeld. Dankzij de 90Hz-verversingssnelheid worden beelden vloeiend weergegeven. Vier cameraâ€™s Op de achterkant vind je maar liefst vier cameraâ€™s. Deze hebben allemaal een eigen functie, zoals de groothoeklens die een bredere kijkhoek heeft. Van de kwaliteit moet je geen wonderen verwachten, maar het is goed genoeg om de fotoâ€™s te delen op bijvoorbeeld social media. Hele dag genoeg stroom Dankzij de 5000mAh-accu heb je de hele dag genoeg accu. Opladen gaat via de USB-C oplader. Dit gaat met een 10W-snelheid en dit valt niet onder snelladen. Als je de telefoon bijvoorbeeld â€™s nachts oplaadt heb je daar natuurlijk geen last van. Genoeg ruimte De opslagcapaciteit van de Moto G20 Blauw bedraagt 64GB. Dit is genoeg voor de meeste mensen, want hierop kun je een hoop apps en bestanden kwijt. Als je toch niet genoeg ruimte hebt is het mogelijk om een microSD-kaartje te gebruiken om het uit te breiden!",
                Price = 1028,
                Stock = 17,
                BrandId = 3
            });
        }
    }
}