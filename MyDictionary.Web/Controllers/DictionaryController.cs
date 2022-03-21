using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MyDictionary.Web.Controllers
{
    public class DictionaryController : Controller
    {
        private IWebHostEnvironment _env;
        private IMemoryCache _cache;
        private const string _CACHE_KEY = "english-dictionary";

        public DictionaryController(IWebHostEnvironment env, IMemoryCache cache)
        {
            _env = env;
            _cache = cache;
        }

        public IActionResult Index(string query)
        {            
            var words = new List<DictionaryEntry>();

            if (query != null)
            {
                var dictionary = _cache.Get<EnglishDictionary>(_CACHE_KEY);

                if (dictionary == null)
                {
                    dictionary = EnglishDictionary.Create(_env.ContentRootPath);
                    _cache.Set<EnglishDictionary>(_CACHE_KEY, dictionary, TimeSpan.FromSeconds(30));
                }

                words = dictionary.Search(query);
            }

            return View(words);
        }
    }
}
