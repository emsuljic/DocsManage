import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  private currentDocument = new ReplaySubject<Document>(1);
  currentDocument$ = this.currentDocument.asObservable();

  addDocument(model: any){
    return this.http.post<Document>(this.baseUrl + 'docs/addDocument', model).pipe(
      map((response: Document) =>{
        const doc = response;
        if(doc){
          localStorage.setItem('doc', JSON.stringify(doc));
          this.currentDocument.next(doc);
        }
      })
    )
  }
}
