using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroLauncher.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GalaSoft.MvvmLight.Ioc;

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

        private RepositoryImage _serviceImg;


        //public Game(RepositoryImage serviceImg)
        public Game()
        {
            //_serviceImg = serviceImg;
            _serviceImg = SimpleIoc.Default.GetInstance<RepositoryImage>();
        }

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
                    var file = GameLinks.Where(lnk => lnk.TypeUrl == TypeUrl.MainScreen).FirstOrDefault().Url;
                    TaskAwaiter<string> awaiter = _serviceImg.GetFileDirectUrl(file).GetAwaiter();
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
