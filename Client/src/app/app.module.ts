import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilmyComponent } from './filmy/filmy.component';
import { FormularzComponent } from './formularz/formularz.component';
import { FormsModule } from '@angular/forms';
import { RepozytoriumPamiecioweService } from './repozytorium-pamieciowe.service';
import { FORM_SUBMIT_TOKEN } from './tokens/form-submit.token';
import { GET_DATA_TOKEN } from './tokens/get-data.token';
import localePl from '@angular/common/locales/pl';
import { registerLocaleData } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import { FormSubmitService } from './services/form-submit.service';
import { GetDataService } from './services/get-data.service';

registerLocaleData(localePl);

@NgModule({
  declarations: [
    AppComponent,
    FilmyComponent,
    FormularzComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [
    RepozytoriumPamiecioweService, 
    {
      provide: GET_DATA_TOKEN, useExisting: GetDataService,
    }, 
    {
      provide: FORM_SUBMIT_TOKEN, useExisting: FormSubmitService
    },
    provideHttpClient(),
    { 
      provide: LOCALE_ID, useValue: 'pl-PL' 
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
