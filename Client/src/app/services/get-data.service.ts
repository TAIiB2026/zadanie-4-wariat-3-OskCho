import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { GetDataInterface } from '../interfaces/get-data.interface';
import { FilmClass } from '../classes/film.class';

// Pomocniczy interfejs opisujący surowy obiekt, jaki przysyła C# w formacie JSON
interface FilmDTO {
  id: number;
  tytul: string;
  cena: number;
  dataPremiery: string; // Backend przysyła datę jako string, np. "2010-07-30"
}

@Injectable({
  providedIn: 'root'
})
export class GetDataService implements GetDataInterface {
  private readonly URL = 'http://localhost:5111/api/Form';
  private readonly httpClient = inject(HttpClient);

  Get(): Observable<FilmClass[]> {
    return this.httpClient.get<FilmDTO[]>(this.URL).pipe(
      map(filmyZApi => {
        return filmyZApi.map(film => this.parseFilm(film));
      })
    );
  }

  GetByID(id: number): Observable<FilmClass> {
    const url = `${this.URL}/${id}`;
    return this.httpClient.get<FilmDTO>(url).pipe(
      map(filmZApi => this.parseFilm(filmZApi))
    );
  }

  private parseFilm(dto: FilmDTO): FilmClass {
    const [year, month, day] = dto.dataPremiery.split('-').map(Number);
    const dataPremiery = new Date(year, month - 1, day);
    
    return new FilmClass(dto.id, dto.tytul, dto.cena, dataPremiery);
  }
}