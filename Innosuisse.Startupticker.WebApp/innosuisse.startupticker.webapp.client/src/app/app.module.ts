import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DevExtremeModule, DxButtonModule, DxCheckBoxModule, DxDataGridModule, DxDropDownButtonModule, DxGalleryModule, DxListModule, DxLoadIndicatorModule, DxMenuModule, DxPopupModule, DxSelectBoxModule, DxTabPanelModule, DxTextBoxModule, DxToolbarModule, DxTreeListModule, DxValidatorModule } from 'devextreme-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Configuration } from '../../typescript-client';
import { environment } from '../environment/environment';
import { ReactiveFormsModule } from '@angular/forms';

const apiConfiguration = new Configuration({ basePath: environment.apiBasePath, withCredentials: true });

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DevExtremeModule,
    DxListModule,
    DxTabPanelModule,
    ReactiveFormsModule,
    DxSelectBoxModule,
    DxPopupModule,
    DxDataGridModule,
    DxButtonModule,
    DxTextBoxModule,
    DxCheckBoxModule,
    DxValidatorModule,
    DxToolbarModule,
    DxDropDownButtonModule,
    DxLoadIndicatorModule,
    DxGalleryModule,
    DxTreeListModule,
    DxMenuModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi()),
    { provide: Configuration, useValue: apiConfiguration },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
