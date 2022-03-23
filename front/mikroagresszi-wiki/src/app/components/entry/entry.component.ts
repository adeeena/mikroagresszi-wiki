import {Component, HostListener, Inject, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {EntryService} from "../../services/entry.service";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {fadeInUpOnEnterAnimation} from "angular-animations";

export interface DialogData {
  link: string;
}

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.scss'],
  animations: [
    fadeInUpOnEnterAnimation({ anchor: 'enter1', duration: 1000, delay: 100, translate: '30px' }),
    fadeInUpOnEnterAnimation({ anchor: 'enter2', duration: 1000, delay: 300, translate: '30px' }),
    fadeInUpOnEnterAnimation({ anchor: 'enter3', duration: 1000, delay: 500, translate: '30px' }),
  ]
})
export class EntryComponent implements OnInit {
  public entryId: string = '';
  public entry: any;
  private innerWidth: number = 0;

  constructor(private route: ActivatedRoute,
              private entryService: EntryService,
              public dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.entryId = (params as any).params.id;

      if (this.entryId) {
        this.entryService.getById(this.entryId)
          .subscribe((data: any) => {
            this.entry = data;
            console.dir(this.entry);
          });
      }
    });
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.innerWidth = window.innerWidth;
  }

  openShareDialog(): void {
    this.dialog.open(DialogElementsExampleDialog, {
      width: this.innerWidth <= 600 ? '90vw' : '50vw',
      data: {
        link: location.origin + '/#/entry/' + this.entryId
      }
    });
  }
}

@Component({
  selector: 'share-dialog',
  styleUrls: ['./entry.component.scss'],
  templateUrl: 'entry-dialog.component.html',
})
export class DialogElementsExampleDialog {
  constructor(public dialogRef: MatDialogRef<DialogElementsExampleDialog>,
              @Inject(MAT_DIALOG_DATA) public data: DialogData,
  ) {}

  onClick(): void {
    this.dialogRef.close();
  }
}
