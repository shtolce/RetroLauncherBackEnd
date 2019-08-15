using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WebApiRL.Model
{
    public class Game 
    {
        int gameId;
        public int GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        public string Name { get; set; }
        public string NameSecond { get; set; }
        public string NameOther { get; set; }        
        public string Genre { get; set; }
        public int? Year { get; set; }
        public string Developer { get; set; }

        string annotation;
        public string Annotation
        {
            get { return annotation; }
            set { if (value.Length > 1000) annotation = value.Substring(0, 1000); else annotation = value; }
        }

        public Platform Platform { get; set; }

        private List<GameLink> gameLinks { get; set; }
        public List<GameLink> GameLinks
        {
            get { return gameLinks; }
            set
            {
                gameLinks = value;
            }
        }

        private string imgUrl;
        public string ImgUrl
        {
            get
            {
               
                if (GameLinks != null && string.IsNullOrEmpty(imgUrl))
                {
                    TaskAwaiter<string> awaiter = Services.RepositoryImage.GET(GameLinks.Where(lnk => lnk.TypeUrl == TypeUrl.MainScreen).FirstOrDefault().Url).GetAwaiter();
                    awaiter.OnCompleted(() =>
                    {
                        imgUrl = awaiter.GetResult();
                    });
                }
                return imgUrl;
            }
        }


    }
}
