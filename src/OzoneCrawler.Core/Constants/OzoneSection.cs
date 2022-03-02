using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneCrawler.Core.Constants
{
    public class OzoneSection
    {
        public const string BestSale = "/landing/gaming-madness";
        public const string VideoGames = "/landing/gaming-madness/video-igri.php";
        public const string GamingStuff = "/landing/gaming-madness/gejming_periferiq.php";
        public const string Electronics = "/landing/gaming-madness/elektronika.php";
        public const string TVs = "/landing/gaming-madness/tv_i_monitori.php";
        public const string Figures = "/landing/gaming-madness/figuri.php";
        public const string Merch = "/landing/gaming-madness/chashi_i_klyuchodyrzhateli.php";
        public const string BoardGames = "/landing/gaming-madness/nastolni_igri.php";
        public const string Puzzles = "/landing/gaming-madness/pyzeli.php";
        public const string Movies = "/landing/gaming-madness/filmi.php";

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
