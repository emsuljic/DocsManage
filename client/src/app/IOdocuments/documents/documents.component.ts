import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.css']
})
export class DocumentsComponent implements OnInit {
  @Output() cancelDocument = new EventEmitter();
  model: any = {};

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  cancel(){
    this.cancelDocument.emit(false);
  }

  back(){
    this.router.navigateByUrl('/');
  }
}
