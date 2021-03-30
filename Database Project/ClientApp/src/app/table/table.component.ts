import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  @Input() observable: Observable<any>;
  elements: any;
  page = 1;
  count = 0;
  tableSize = 7;
  tableSizes = [3, 6, 9, 12];

  constructor() { }

  ngOnInit() {
    this.fetch();
  }

  fetch(): void {
    this.observable.subscribe(x => {
      this.elements = x;
    });
  }

  onTableDataChange(event) {
    this.page = event;
  }

  onTableSizeChange(event): void {
    this.tableSize = event.target.value;
    this.page = 1;
  }

}
