using System;
using System.Linq;
using System.Collections.Generic;

namespace PatikaWeek7Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Artist class yeni bir liste üretiliyor...

           List<Artist> artists = new List<Artist>()
           {

             new Artist {NameSurname="Ajda Pekkan",MusicGenre="Pop", ReleaseYear=1968, AlbumSales= 20},
             new Artist {NameSurname="Sezen Aksu",MusicGenre="Türk Halk Müziği/Pop", ReleaseYear=1971, AlbumSales=10},
             new Artist {NameSurname="Funda Arar",MusicGenre="Pop", ReleaseYear=1999, AlbumSales=3 },
             new Artist {NameSurname="Sertab Erener",MusicGenre="Pop", ReleaseYear=1994, AlbumSales= 5},
             new Artist {NameSurname="Sıla",MusicGenre="Pop", ReleaseYear=2009, AlbumSales=3 },
             new Artist {NameSurname="Sertaç Ortaç",MusicGenre="Pop", ReleaseYear=1994, AlbumSales=10 },
             new Artist {NameSurname="Tarkan",MusicGenre="Pop", ReleaseYear=1992, AlbumSales=40},
             new Artist {NameSurname="Hande Yener",MusicGenre="Pop", ReleaseYear=1999, AlbumSales=7 },
             new Artist {NameSurname="Hadise",MusicGenre="Pop", ReleaseYear=2005, AlbumSales=5},
             new Artist {NameSurname="Gülben Ergen",MusicGenre="Pop/Türk Halk Müziği", ReleaseYear=1997, AlbumSales=10},
             new Artist {NameSurname="Neşet Ertaş",MusicGenre="Türk Halk Müziği/Türk Sanat Müziği", ReleaseYear=1960, AlbumSales= 2},
           };

            //linq syntax ile listede üzeirnde sorgular gerçekleştiriliyor

            
            Console.WriteLine("---Adı 'S' ile başlayan şarkıcılar-----------");
            var nameFilter = from artist in artists
                             where artist.NameSurname.StartsWith('S')
                             select artist;

            ArtistPrint(nameFilter);


            Console.WriteLine("\n---Albüm satışları 10 milyon'un üzerinde olan şarkıcılar---------------");
            var albümSalesFilter = from artist in artists
                                   where artist.AlbumSales > 10
                                   select artist;
            ArtistPrint(albümSalesFilter);



            Console.WriteLine("\n---2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar.------------------");

                var artistFilter = from artist in artists
                                   where artist.ReleaseYear < 2000 && artist.MusicGenre.Contains("Pop")
                                   group artist by new 
                                   { 
                                       ReleaseYear=artist.ReleaseYear ,
                                       NameSurname=artist.NameSurname,

                                   } into artistGroup
                                   orderby artistGroup.Key.NameSurname ascending
                                   select artistGroup;


            foreach (var group in artistFilter)
            {
                
                foreach (var artist in group)
                {
                    Console.WriteLine(artist.NameSurname);
                }
                Console.WriteLine(group.Key);
            }



            Console.WriteLine("\n--En çok albüm satan şarkıcı---------------------");

            var artistMax = (from artist in artists
                             orderby artist.AlbumSales descending
                             select artist).FirstOrDefault();

            Console.WriteLine("En yüksek satış yapan şarkıcı..:" + artistMax.NameSurname);




            Console.WriteLine("\n--En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı-------------");
            var artistMaxYear = (from artist in artists
                                orderby artist.ReleaseYear descending
                                select artist).FirstOrDefault();

            var artistMinYear = (from artist in artists
                                 orderby artist.ReleaseYear 
                                 select artist).FirstOrDefault();
            Console.WriteLine(" En yeni çıkış yapan şarkıcı..:" + artistMaxYear.NameSurname + "\n En eski çıkış yapan şarkıcı..:"+artistMinYear.NameSurname);

        }


        /// <summary>
        /// Sorguların ekrana yazdırılması..
        /// </summary>
        /// <param name="artists"></param>
        static void ArtistPrint(IEnumerable<Artist> artists)
        {
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.NameSurname);
            }
        }
    }

    
}
