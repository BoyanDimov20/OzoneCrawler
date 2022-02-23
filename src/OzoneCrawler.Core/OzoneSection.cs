using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneCrawler.Core
{
    public class OzoneSection
    {
        public static string BestSale = "/landing/gaming-madness";
        public static string VideoGames = "/landing/gaming-madness/video-igri.php";
        public static string GamingStuff = "/landing/gaming-madness/gejming_periferiq.php";
        public static string Electronics = "/landing/gaming-madness/elektronika.php";
        public static string TVs = "/landing/gaming-madness/tv_i_monitori.php";
        public static string Figures = "/landing/gaming-madness/figuri.php";
        public static string Merch = "/landing/gaming-madness/chashi_i_klyuchodyrzhateli.php";
        public static string BoardGames = "/landing/gaming-madness/nastolni_igri.php";
        public static string Puzzles = "/landing/gaming-madness/pyzeli.php";
        public static string Movies = "/landing/gaming-madness/filmi.php";

        public static IList<string> Sections { get; } = new string[] {
            BestSale,
            VideoGames,
            GamingStuff,
            Electronics,
            TVs,
            Figures,
            Merch,
            BoardGames,
            Puzzles,
            Movies
        };
        
    }
}
