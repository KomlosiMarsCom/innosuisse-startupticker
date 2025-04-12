import { Component, OnInit } from '@angular/core';
import { DataSourceLoadOptions, RawDataService } from '../../typescript-client';
import { lastValueFrom } from 'rxjs';
import { CustomStore, DataSource } from 'devextreme-angular/common/data';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  dataSource: DataSource<any, any>;
  store: CustomStore;
  constructor(private readonly _rawDataService: RawDataService) {
    this.store = new CustomStore({
      key: 'id',
      load: (opt) => {
        return lastValueFrom(this._rawDataService.gridDataCrunchbasePost(opt as DataSourceLoadOptions))
      }
    });

    this.dataSource = new DataSource(this.store);
  }

  ngOnInit() {
  }

  title = 'innosuisse.startupticker.webapp.client';
}
