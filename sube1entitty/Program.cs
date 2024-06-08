// See https://aka.ms/new-console-template for more information
using sube1entitty;
namespace ConsoleApp
{
    public class Progress
    {
        static void Main(String[] args)
        {
            //var ogr = new Ogrenci {Ad="İrem", Soyad="Çelik",numara=797 };
            //using (var ctx = new OkulDbContext())
            //{
            //    ctx.Ogrenciler.Add(ogr);
            //    ctx.SaveChanges();//insert örneği
            //}
            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(1);
            //    if (ogr!=null)
            //    {
            //        ogr.numara = 789;
            //        ctx.SaveChanges();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Böyle Bir Öğrenci Bulunamadı!!!!");
            //    }
            //}  güncelleme işlemi
            //using (var ctx = new OkulDbContext())
            //{
            //    var ogr = ctx.Ogrenciler.Find(1);
            //    ctx.Ogrenciler.Remove(ogr);
            //    ctx.SaveChanges();
            //}silme işlemi
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.Ad);
                }//öğrenci listeleme
            }
        }
    }
}

