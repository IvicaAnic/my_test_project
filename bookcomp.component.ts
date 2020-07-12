import { Component, OnInit } from '@angular/core';
import {Book} from '../Model/Book'
import { FormControl,FormGroup ,FormBuilder,Validators} from '@angular/forms'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bookcomp',
  templateUrl: './bookcomp.component.html',
  styleUrls: ['./bookcomp.component.scss']
})
export class BookcompComponent implements OnInit {

  form1: FormGroup;
  bookwebapiresult;
  httpClient:HttpClient;
  BooksModels:Array<Book> = new Array<Book>();
  constructor(private fb:FormBuilder,private httpclient:HttpClient) { 
    this.httpClient=httpclient;
    this.form1 = fb.group({
      BookTitle: ['BookTitle', [Validators.required]],
      BookPrice: ['BookPrice', [Validators.required]],
      Author: ['Author', [Validators.required]],
      BookVerlag: ['BookVerlag', [Validators.required]],
      BookISDN: ['BookISDN', [Validators.required]],

  });

  var num:number = 0; 
var i:number; 
var factorial = 1; 

for(i = num;i< 15;i++) {
  var BookModel: Book = new Book();
  BookModel.AuthorId=i;
  BookModel.BookISDN='QQQAADDFFF11';
  BookModel.BookPrice=99.9;
  BookModel.BookTitle="my book title " + i;
  BookModel.BookVerlag="my book verlag " +i;
  this.BooksModels.push(BookModel);
}

  }
  loadbooks()
  {
   this.httpClient.get("https://jsonplaceholder.typicode.com/posts").subscribe((value:any)=> { 
     this.bookwebapiresult=value
     console.log(this.bookwebapiresult);
    
    });
   
  
  }

  ngOnInit(): void {
  }

}
