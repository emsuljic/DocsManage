import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DocumentService } from 'src/app/_services/document.service';


// export enum VrstaDokumenta {
//   Faktura = "Faktura",
//   Potvrda = "Potvrda",
//   Ugovor = "Ugovor",
//   Ponuda = "Ponuda",
//   Opomena = "Opomena",
//   Dopis = "Dopis"
// }

// export enum TipDokumenta{
//   Ulzni = "Ulazni",
//   Izlazni = "Izlazni"
// }

// export const VrstaDokumenta2LabelMapping: Record<VrstaDokumenta, string> = {
//   [VrstaDokumenta.Faktura]: "Faktura",
//   [VrstaDokumenta.Potvrda]: "Potvrda",
//   [VrstaDokumenta.Ugovor]: "Ugovor",
//   [VrstaDokumenta.Ponuda]: "Ponuda",
//   [VrstaDokumenta.Opomena]: "Opomena",
//   [VrstaDokumenta.Dopis]: "Dopis",
// };

// export const TipDokumenta2LabelMapping: Record<TipDokumenta, string> ={
//   [TipDokumenta.Ulzni]: "Ulazni",
//   [TipDokumenta.Izlazni]: "Izlazni"
// }

@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html',
  styleUrls: ['./documents.component.css']
})
export class DocumentsComponent implements OnInit {
  @Output() cancelDocument = new EventEmitter();
  model: any = {};
  // vrstaDokumenta = VrstaDokumenta;
  // enumKeys: string[] = [];

  // public VrstaDokumenta2LabelMapping = VrstaDokumenta2LabelMapping;
  // public vrstaDokumenta = Object.values(VrstaDokumenta);

  // public TipDokumenta2LabelMapping = TipDokumenta2LabelMapping;
  // public tipDokumenta = Object.values(TipDokumenta);

  selectedVrsta: string = '';
  selectChangeHandlerVrsta(event: any) {
    this.selectedVrsta = event.target.value;
  }

  selectedTip: string = '';
  selectChangeHandlerTip(event: any){
    this.selectedTip = event.target.value;
  }

  constructor(private router: Router, private documentService: DocumentService,
    private toastr: ToastrService, private fb: FormBuilder) {
    // this.enumKeys = Object.keys(this.vrstaDokumenta);
  }

  ngOnInit(): void {
  }

  // addDocument() {
  //   this.documentService.addDocument(this.model).subscribe(response => {
  //     console.log(response);
  //     this.cancel();
  //   }, error => {
  //     console.log(error);
  //     this.toastr.error(error.error);
  //   })
  // }

  addDocument(){
    this.documentService.addDocument(this.model);
  }

  cancel() {
    this.cancelDocument.emit(false);
  }

  back() {
    this.router.navigateByUrl('/');
  }

}
