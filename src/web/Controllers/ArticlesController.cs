using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dal;

namespace web.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        SampleContext _db;
        public ArticlesController()
        {
            _db = new SampleContextFactory().CreateDbContext(null);
        }

        // GET api/articles
        [HttpGet]
        public IEnumerable<Article> List()
        {
            var articles = _db.Articles;
            return articles;
        }

        // GET api/articles/5
        [HttpGet("{id}")]
        public Article Get(int id)
        {
            var article = _db.Articles.Where(a => a.Id == id).SingleOrDefault();
            return article;
        }

        // GET api/articles/add
        [HttpGet("add")]
        public Article AddGet(string name)
        {
            Article article = new Article()
            {
                Name = name,
            };

            _db.Articles.Add(article);
            _db.SaveChanges();

            return article;
        }
    }
}
