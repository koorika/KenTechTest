using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverSupport
{
    public static class URIS
    {
        //amazon;hbo_go;itunes;netflix_iw;vudu;amazon_prime;fandango_now - providers
        //1;2;4;5;6;8;9;10;11;13;18;14 - genres
        //popularity 
        // This is not used, but is a safetly net. Wherever the selection of the filters would be too costly to implement,
        // We can just rewrite the URL and introduce any filter values we need
        public static string FilteringURI = "https://www.rottentomatoes.com/browse/top-dvd-streaming?minTomato={0}" +
            "&maxTomato=100&certified={1}" +
            "&services={2}" +
            "&genres={3}" +
            "&sortBy={5}";
    }
}
