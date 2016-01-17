# Introduction #

This library is designed to work with http://cinemate.cc/api/.


# Details #

1) Download the compiled dll library
2) Reference it in your VisualStudio project
3) Create the instance of CinemateAPI class

var api = new CinemateAPI.CinemateAPI("[IS YOUR MEMBER CODE](HERE.md)");
or
var api = new CinemateAPI.CinemateAPI();

4) Use this instance to get the information from the Cinemate.cc website

var NewMovies = api.Movie\_New();

var MovieSearch = api.Movie\_Search("Трансформеры");

var SiteStatistic = api.Stats\_New();

var PersonSearch = api.Person\_Search("Джек");

var WatchList = api.Account\_Watchlist();

var Updates = api.Account\_Updatelist();

var Account = api.Account\_Profile();