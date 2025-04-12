import { Component, OnInit } from '@angular/core';
import { DataSourceLoadOptions, ProcessedDataService, RawDataService } from '../../typescript-client';
import { lastValueFrom } from 'rxjs';
import { CustomStore, DataSource } from 'devextreme-angular/common/data';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  dataSourceCrunchbase: DataSource<any, any>;
  storeCrunchbase: CustomStore;

  dataSourceStartupticker: DataSource<any, any>;
  storeStartupticker: CustomStore;

  dataSourceStartups: DataSource<any, any>;
  storeStartups: CustomStore;
  constructor(private readonly _rawDataService: RawDataService, private readonly _processedDataService: ProcessedDataService) {
    this.storeCrunchbase = new CustomStore({
      key: 'id',
      load: (opt) => {
        return lastValueFrom(this._rawDataService.gridDataCrunchbasePost(opt as DataSourceLoadOptions))
      }
    });

    this.dataSourceCrunchbase = new DataSource(this.storeCrunchbase);

    this.storeStartupticker = new CustomStore({
      key: 'title',
      load: (opt) => {
        return lastValueFrom(this._rawDataService.gridDataStartuptickerPost(opt as DataSourceLoadOptions))
      }
    });

    this.dataSourceStartupticker = new DataSource(this.storeStartupticker);

    this.storeStartups = new CustomStore({
      key: 'id',
      load: (opt) => {
        return lastValueFrom(this._processedDataService.gridDataStartupsPost(opt as DataSourceLoadOptions))
      }
    });

    this.dataSourceStartups = new DataSource(this.storeStartups);
  }

  ngOnInit() {
  }

  title = 'innosuisse.startupticker.webapp.client';
}
