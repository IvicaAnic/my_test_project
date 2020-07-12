import { Component, OnInit } from '@angular/core';
import {Author} from '../Model/Author'
import { FormControl,FormGroup ,FormBuilder,Validators} from '@angular/forms'

@Component({
  selector: 'app-authorcomp',
  templateUrl: './authorcomp.component.html',
  styleUrls: ['./authorcomp.component.scss']
})
export class AuthorcompComponent implements OnInit {

  form: FormGroup;
  AuthorModels:Array<Author> = new Array<Author>();
  constructor(private fb:FormBuilder,) { 
    this.form = fb.group({
      AuthorName: ['AuthorName', [Validators.required]],
      AuthorVorname: ['AuthorVorname', [Validators.required]],
      Stadt: ['Stadt', [Validators.required]],
      Strasse: ['Strasse', [Validators.required]],
      PLZ: ['PLZ', [Validators.required]],

  });

  var num:number = 0; 
  var i:number; 
  var factorial = 1; 
  
  for(i = num;i< 15;i++) {
    var AuthorModel: Author = new Author();
    AuthorModel.AuthorName="Lothar" + i;
    AuthorModel.AuthorVorname='Matthäuse';
    AuthorModel.Strasse='könig strasse 1 ' +i;
    AuthorModel.PLZ="7089 " + i;
    AuthorModel.Stadt="Stuttagrt " +i;
    this.AuthorModels.push(AuthorModel);
  }





  }

  ngOnInit(): void {
  }

}
