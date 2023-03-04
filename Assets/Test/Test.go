package main

import (
	"database/sql"
	"log"
	"net/http"

	"github.com/ant0ine/go-json-rest/rest"

	_ "github.com/mattn/go-sqlite3"
)

type Test struct {
	ID      int
	Name    string
	comment string
}

var test = map[int]*Test{}

func main() {
	api := rest.NewApi()
	api.Use(rest.DefaultDevStack...)

	router, err := rest.MakeRouter(
		rest.Get("/getAllData", GetAllData),
	)
	if err != nil {
		log.Fatal(err)
	}
	api.SetApp(router)
	log.Printf("Server Started.")

	// APIサーバを起動.
	log.Fatal(http.ListenAndServe("", api.MakeHandler()))
}

func GetAllData(w rest.ResponseWriter, r *rest.Request) {
	con, er := sql.Open("sqlite3", "Test.sqlite3")
	if er != nil {
		panic(er)
	}
	defer con.Close()

	q := "select * from Test"
	rs, er := con.Query(q)
	if er != nil {
		panic(er)
	}
	for rs.Next() {
		var ts Test
		er := rs.Scan(&ts.ID, &ts.Name, &ts.comment)
		if er != nil {
			panic(er)
		}

		w.WriteJson(&ts)
	}
}
