using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AgriDoktorum.WebApp.Models.Entity;

namespace AgriDoktorum.WebApp.Models.EntityDb
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            //ADD : admin
            var admin = new AdUser()
            {
                Name = "Alihan",
                Surname = "Tanrıverdi",
                Username = "AlihanT",
                Email = "alhntnrvrd@gmail.com",
                Password = "Qwerty123"
            };
            context.AdUsers.Add(admin);
            context.SaveChanges();


            //Add About
            var about = new List<About>()
            {
                new About
                {
                    AboutTitle= "UZM.DR.AHMET DALMIZRAK",
                    AboutDescription = "İlk ve orta öğrenimini Mersin’de tamamlayan Dr. Ahmet Dalmızrak, 1997 yılında " +
                                       "İstanbul Üniversitesi Cerrahpaşa Tıp Fakültesinden (İngilizce Tıp) mezun oldu." +
                                       "1998 yılında başladığı İstanbul Eğitim ve Araştırma Hastanesi Anestezi  ve Reanimasyon Uzmanlık Eğitimini 2003 yılında tamamladı. " +
                                       "2004-2005 yılları arasında Amerika Birleşik Devletlerinde Baltimore şehrinde bulunan University of Maryland School of Medicine de " +
                                       "Romatoloji ve İmmünoloji bölümünde Postdoctoral Research Fellow olarak çalıştı. Amerika’da doktorluk yapmak için girilmesi gereken " +
                                       "USMLE sınavlarını başarı ile geçerek ECFMG belgesi aldı. 2006 yılında Türkiye’ye döndü ve o tarihten bu yana da İstanbul’da Uzman " +
                                       "doktor olarak görev yapmaktadır." +
                                       "Yenilikçi düşünce ve farklı fikirlere sahip olan Dr. Ahmet Dalmızrak’ın tıp haricinde diğer konularda da patent ve" +
                                       " araştırmaları bulunmaktadır."
                }
            };

            foreach (var item in about)
            {
                context.About.Add(item);
            }
            context.SaveChanges();

            //Add Categories
            for (var i = 0; i < 3; i++)
            {
                var categories = new List<Category>()
                {
                    new Category
                    {
                        CategoryTitle = FakeData.PlaceData.GetStreetName(),
                        CategoryDescription = FakeData.PlaceData.GetAddress()
                    }
                };
                foreach (var itemCategory in categories)
                {
                    context.Categories.Add(itemCategory);
                }
                context.SaveChanges();
            }

            //Add Blogs
            for (var j = 0; j < FakeData.NumberData.GetNumber(5, 9); j++)
            {
                var blogs = new List<Blog>()
                {
                    new Blog
                    {
                        BlogTittle = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        BlogDescription = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(10, 20)),
                        BlogText = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(50, 90)),
                        BlogImage = "BlogsImage.jpg",
                        ModifiedOn = DateTime.Now,
                        ModifiedUsername = admin.Username,
                        CreatedOn = DateTime.Now,
                        CategoryId = 1
                    }

                };
                foreach (var item in blogs)
                {
                    context.Blogs.Add(item);
                }
                context.SaveChanges();
            }


            //Add Treatment
            var treatments = new List<Treatment>()
            {
                new Treatment
                {
                    TreatmentTitle = "KOMBİNE MİGREN TEDAVİSİ",
                    TreatmentImage = "1.png",

                    TreatmentText = "KOMBİNE TEDAVİ ile Sinir Blokları, Radyofrekans, Ozon Terapi, Nöral Terapi, Mezoterapi, Nöralproloterapi," +
                                    " Akupunktur, Tetik Nokta Enjeksiyonu, Manüel Terapi Yöntemlerinin birinin veya bir kaçının bir arada uygulanması şeklinde yapılır." +
                                    "Kombine Tedavi uygulanması sonrasında daha ilk seanstan itibaren MİGREN Atak sıklığının azaldığı ve " +
                                    "MİGREN atağı başlamışsa bile bu atağın kısa sürede geçtiği hastalarımız tarafından ifade edilmektedir." +
                                    "Bazı hastalarımız ilk seans sonrasında bile tamamen iyileşmekte ve kullanmakta oldukları " +
                                    "ilaçlardan da kalıcı olarak kurtulabilmektedir. "
                },
                new Treatment{
                    TreatmentTitle= "PROLOTERAPİ",
                    TreatmentImage = "2.png",
                    TreatmentText = "Proloterapi, 1900 yılların başından itibaren özellikle Amerika’da uygulanmasına rağmen, 2000’li yıllardan itibaren tüm dünyada " +
                                     "ve ülkemize ağrılı hastalıkların tedavisinde kullanılmaya başlanmıştır.Proloterapi uygulaması; farmakolojik ya da biyolojik olarak aktif olmayan," +
                                     " irritan bir sıvı içeriğini vücuda, genellikle de tendon, ligament veya konnektif doku içerisine güçlendirme veya ağrı tedavisi amacıyla enjekte etmektir. " +
                                     "Enjekte edilen proliferatif maddeler eklemde, tendonların kaslarla birleşme noktalarında ve kasların kemiğe yapışma yerlerinde, fibro - osseöz " +
                                     "bileşkede(enthesis) inflamatuar bir süreç başlatır. Bu inflamasyon tamir mekanizmasını tetikler, gerek kıkırdak dokusunda gerekse kollajen fibrillerin oluşmasında ve " +
                                     "tamirinde yeni bir süreç başlatır.İyileşme ile birlikte eklemin stabilizasyonunun artması ile ağrı ortadan kalkar. "
                }
            };
            foreach (var item in treatments)
            {
                context.Treatments.Add(item);
            }
            context.SaveChanges();

            //ADD Patient
            var patients = new List<PatientReference>()
            {
                new PatientReference
                                        {
                                            ReferenceName = "Adnan",
                                            ReferenceSurname = "Atıcı",
                                            ReferenceImage = "adnanatici.jpg",
                                            ReferenceRemark = "Son 2 yıldır bel bölgemde genellikle beni sabah saatlerinde rahatsız eden şiddetli bel ağrılarım " +
                                            "vardı. Ağrı kesici ilaçlar kullanamama rağmen şikayetlerimde azalma olmadı. Hayat kalitemi etkileyen " +
                                            "ağrılarım nedeni ile Dr Ahmet Beye başvurdum. Belimin değişik bölgelerine iğne tedavisi uyguladı. " +
                                            "Ağrılarım 2. günden itibaren çok azaldı. Şu an ise çok rahatım. Dr Ahmet Dalmızrak’a teşekkür ediyorum."
                                        },
                new PatientReference
                                        {
                                            ReferenceName = "Bilal",
                                            ReferenceSurname = "Dinç",
                                            ReferenceImage = "bilaldinc.jpg",
                                            ReferenceRemark = "Yaklasik 10 gündür bel fitigi nedeniyle bel ve kalca agrilarim oluyordu ameliyat disinda bircok" +
                                            " sey denedim ama fayfasi olmayınca Ahmet bey in epidural enjeksiyon tedavisi onerisi oldu. Ilk etap da " +
                                            "biraz cekindim riskli bir bolge ve cok agrili olur diye sandim ama basit bir igne kadar agri yapti ve " +
                                            "etkisi cabuk basladi ve yaklasik 1 ay oldu ilk agrilarimin cogu gitti duruşum yuruyuşum duzeldi, yururken " +
                                            "bile disardan farkedilebiliyor. Kendisine cok tesekkur ediyorum"

                                        }
            };
            foreach (var item in patients)
            {
                context.PatientReferences.Add(item);
            }
            context.SaveChanges();

            //ADD Gallery
            var galleries = new List<Gallery>()
            {
                new Gallery
                {
                    Description="özel KOMBİNE TEDAVİ yöntemi ile MİGREN ağrıları kalmayan hastamız artık İLAÇ kullanmıyor",
                    VideoUrl="https://www.youtube.com/embed/-gHVc_zeWoc"
                },
                new Gallery
                {
                    Description="KOMBİNE TEDAVİ ile MİGREN-ÇENE AĞRISI TEDAVİSİ",
                    VideoUrl="https://www.youtube.com/embed/C6nz9F38Di4"
                }
            };
            foreach (var item in galleries)
            {
                context.Galleries.Add(item);
            }
            context.SaveChanges();


            //Add Contact
            var contacts = new List<Contact>()
            {
                new Contact
                {
                    Address = "Merkez Mahallesi Güngören İstanbul",
                    TelNo = "0532 654 42 40",
                    Email = "adalmizrak@gmail.com"
                }
            };
            foreach (var item in contacts)
            {
                context.Contact.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}