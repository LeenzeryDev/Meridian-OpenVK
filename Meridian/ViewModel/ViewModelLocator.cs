﻿using System;
using EchonestApi;
using LastFmLib;
using Meridian.Services;
using Meridian.ViewModel.Main;
using VkLib;
using Meridian.Domain;

namespace Meridian.ViewModel
{
    public class ViewModelLocator
    {
        private static Lazy<MainViewModel> _main = new Lazy<MainViewModel>(() => new MainViewModel());
        private static Lazy<NowPlayingViewModel> _nowPlaying = new Lazy<NowPlayingViewModel>(() => new NowPlayingViewModel());
        private static readonly Vkontakte _vkontakte = new Vkontakte("2685278", "lxhD8OD7dMsqtXIm5IUY", "5.92", "KateMobileAndroid/51.2 lite-443 (Android 4.4.2; SDK 19; x86; unknown Android SDK built for x86; en)");
        private static readonly LastFm _lastFm = new LastFm("a012acc1e5f8a61bc7e58238ce3021d8", "86776d4f43a72633fb37fb28713a7798");
        private static readonly Echonest _echonest = new Echonest("RSKOILYE1AHENGSO8");

        public static MainViewModel Main
        {
            get { return _main.Value; }
        }

        public static NowPlayingViewModel NowPlaying
        {
            get { return _nowPlaying.Value; }
        }

        public static Vkontakte Vkontakte
        {
            get { return _vkontakte; }
        }

        public static LastFm LastFm
        {
            get { return _lastFm; }
        }

        public static Echonest Echonest
        {
            get { return _echonest; }
        }

        public ViewModelLocator()
        {

        }
    }
}
