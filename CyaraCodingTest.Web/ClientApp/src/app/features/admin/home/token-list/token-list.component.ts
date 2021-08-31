import { ChangeDetectionStrategy, Component, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { EventEmitter } from 'events';
import { ApiToken } from 'src/app/shared/models/token.model';

@Component({
  selector: 'app-token-list',
  templateUrl: 'token-list.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class TokenListComponent implements OnInit {

  @Input()
  tokens: ApiToken[];

  displayedColumns = ['token', 'appUrl', 'validTo', 'isActive'];

  dataSource = new MatTableDataSource<ApiToken>([]);

  constructor() { }

  ngOnInit() { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['tokens']) {
      this.dataSource.data = this.tokens;
    }
  }

  toggleStatus(token: ApiToken) {

  }
}