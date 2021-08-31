import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-create-token',
  templateUrl: 'create-token.component.html'
})

export class CreateTokenComponent implements OnInit {
  form: FormGroup;
  
  constructor(
    public dialogRef: MatDialogRef<CreateTokenComponent>,
    private fb: FormBuilder
  ) { }

  ngOnInit() { 
    this.form = this.fb.group({
      appUrl: [null, Validators.required],
    });
  }

  onNoClick(): void {
    this.dialogRef.close(null);
  }
}