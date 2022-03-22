import {Component, Inject, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {EntryService} from "../../services/entry.service";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

export interface DialogData {
  link: string;
}

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrls: ['./entry.component.scss']
})
export class EntryComponent implements OnInit {
  public entryId: string = '';
  public entry: any;

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

  openShareDialog(): void {
    this.dialog.open(DialogElementsExampleDialog, {
      width: '50vw',
      data: {
        link: location.origin + '/entry/' + this.entryId
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
