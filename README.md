#This is movie service application which will cater for movie browse, add new movie and update existing move#
#Build on asp.net core 2.0 web api
#For smooth build use Visual Studio 2017
endpoint "/Movies" 

This service should be able to perform the following:
1) Fetch movies from the third party datasource.  
   Done. endpoint "/Movies"  
2) Return movies in a sorted order by any of the movie attributes. (Except for the field “Cast”)
   Done. Sorting done on Title. Route "/SortedListbyTitle". 
   I was not clear whether to add functionality to be able to sort all field except Cast. Need to confirm.
3) Search across all fields within the movie.
   Not done. Partial code implemented. Parameters defined. Was not able to complete because of time. 
4) Insert new movie
   Done. Post "/Movies"
5) Update existing movie.
   Done. Put /Movies/{id}
