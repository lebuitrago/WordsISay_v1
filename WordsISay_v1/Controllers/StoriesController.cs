using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WordsISay_v1.Models;

namespace WordsISay_v1.Controllers
{
    public class StoriesController : ApiController
    {
        private WordsISay_v1_Context db = new WordsISay_v1_Context();

        // GET api/Stories

        public IEnumerable<Story> GetStories(string q = null, string sort = null, bool desc = false,
                                                                int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<Story>();

            // Sorts DESC or ASC order if specified by caller
            IQueryable<Story> items = string.IsNullOrEmpty(sort) 
                ? list.OrderBy(o => o.DateCreated)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            // Supports a search functionality by allowing user to specify a text to search for
            if (!string.IsNullOrEmpty(q) && q != "undefined")
            {
                items = items.Where(t => t.Plot.Contains(q));
            }

            // Supports starting at the 'nth' record with the OFFSET parameter
            if (offset > 0)
            {
                items = items.Skip(offset);
            }

            // Limits the number of items to specified amount
            if (limit.HasValue)
            {
                items = items.Take(limit.Value);
            }

            return items;
        }

        // GET api/Stories/5
        public Story GetStory(int id)
        {
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return story;
        }

        // PUT api/Stories/5
        public HttpResponseMessage PutStory(int id, Story story)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != story.StoryId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(story).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Stories
        public HttpResponseMessage PostStory(Story story)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(story);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, story);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = story.StoryId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Stories/5
        public HttpResponseMessage DeleteStory(int id)
        {
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Stories.Remove(story);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, story);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}