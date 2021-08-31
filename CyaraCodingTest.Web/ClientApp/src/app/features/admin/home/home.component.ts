import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CreateTokenComponent } from './create-token/create-token.component';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [HomeService]
})
export class HomeComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    public homeService: HomeService
  ) {
    
  }

  ngOnInit(): void {
    this.homeService.loadTokens();
  }

  addNew() {
    const dialogRef = this.dialog.open(CreateTokenComponent, {
      width: '500px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) {
        return;
      }

      this.homeService.createToken(result.appUrl);
    });
  }
}
