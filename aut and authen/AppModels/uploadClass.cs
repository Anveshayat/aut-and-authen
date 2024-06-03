using aut_and_authen.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace aut_and_authen.AppModels.CRUDOperation.Repository
{
    public class RepositoryClass
    {
   public static string Addmodel(IFormFile formFile)
        {
            var strongpath = Path.Combine(Directory.GetCurrentDirectory());
            if(!Directory.Exists(strongpath))
            {
                Directory.CreateDirectory(strongpath);
            }
            var unique = $"{formFile.FileName}";
            var combine = Path.Combine(strongpath, unique);
            using (var stream = new FileStream(combine, FileMode.Create)) 
            {
                formFile.CopyTo(stream);
            }
            using(UserDbContext db = new UserDbContext())
            {
                Updating filess = new Updating()
                {
                    Filename = formFile.FileName,
                    Filepath = formFile.FileName,
                };
                db.Updatings.Add(filess);
                db.SaveChanges();
            }
            return combine;
        }

        public static Updating download (int id)
        {
            using (UserDbContext userdb = new UserDbContext())
            {
                var upp = userdb.Updatings.Where(x => x.Id == id).FirstOrDefault();

                return upp;
            }
        }       
    }
        }
    

