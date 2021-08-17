import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import  $  from 'jquery';

@Component({
  selector: 'app-protocol-book',
  templateUrl: './protocol-book.component.html',
  styleUrls: ['./protocol-book.component.css']
})
export class ProtocolBookComponent implements OnInit {
  //@ViewChild('dataTable') table!: { nativeElement: any; };
  dataTable: any;
 
  constructor() { }

  ngOnInit(): void {
    //this.dataTable = $(this.table?.nativeElement);
    // this.dataTable.dataTable();
    
  }

}
