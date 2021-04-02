import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { element } from 'protractor';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  //@Input() observable: Observable<any>;
  @Input() elements: Array<object>;
  @Output() elementClicked = new EventEmitter<object>();
  @Input() title?: string;

  headers: Array<string>;
  headerNames: Array<string> = ['ID', 'Name', 'Year', 'Length']
  page = 1;
  count = 0;
  tableSize = 3;
  tableSizes = [3, 6, 9, 12];

  constructor() { }

  ngOnInit() {
    this.headers = Object.keys(this.elements[0]).filter(x =>
      x != "artist" &&
      x != "genre"
      && x != "artistID"
      && x != "genreID");
  }

  onTableDataChange(event) { 
    this.page = event;
  }

  onTableSizeChange(event): void {
    this.tableSize = event.target.value;
    this.page = 1;
  }

  updateElement(element: object): void {
    console.log("song: ", element);
    this.elementClicked.emit(element);
  }
}
