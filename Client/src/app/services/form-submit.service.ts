import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormSubmitInterface } from '../interfaces/form-submit.interface';

@Injectable({
  providedIn: 'root'
})
export class FormSubmitService implements FormSubmitInterface {
  private readonly URL = 'http://localhost:5111/api/Form';
  private readonly httpClient = inject(HttpClient);

  Post(nazwa: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      id: 0,
      tytul: nazwa,
      cena: cena,
      dataPremiery: data
    };
    return this.httpClient.post<boolean>(this.URL, body);
  }

  Put(id: number, nazwa: string, cena: number, data: Date): Observable<boolean> {
    const body = {
      id: id,
      tytul: nazwa,
      cena: cena,
      dataPremiery: data
    };
    
    const url = `${this.URL}/${id}`;
    return this.httpClient.put<boolean>(url, body);
  }
}