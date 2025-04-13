import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DevExtremeModule, DxButtonModule, DxChatModule, DxCheckBoxModule, DxDataGridModule, DxDropDownButtonModule, DxGalleryModule, DxListModule, DxLoadIndicatorModule, DxMenuModule, DxPopupModule, DxResponsiveBoxModule, DxSelectBoxModule, DxTabPanelModule, DxTextBoxModule, DxToolbarModule, DxTreeListModule, DxValidatorModule } from 'devextreme-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Configuration } from '../../typescript-client';
import { environment } from '../environment/environment';
import { ReactiveFormsModule } from '@angular/forms';
import { DetailViewComponent } from './detail-view/detail-view/detail-view.component';
import { ChatBotComponent } from './chat/chat.component';
import { TagsComponent } from './tags/tags.component';

const apiConfiguration = new Configuration({ basePath: environment.apiBasePath, withCredentials: true });

@NgModule({
  declarations: [
    AppComponent,
    DetailViewComponent,
    ChatBotComponent,
    TagsComponent
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
    DxMenuModule,
    DxChatModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi()),
    { provide: Configuration, useValue: apiConfiguration },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
