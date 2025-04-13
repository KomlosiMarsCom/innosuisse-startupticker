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

  dateFormat: string = "dd/MM/yyyy";

  fromYear: number = new Date().getFullYear() - 5;
  toYear: number = new Date().getFullYear();

  fundingByYear: any[] = [];
  fundingByCanton: any[] = [];
  startupsByIndustry: any[] = [];
  industrySeries: { name: string, valueField: string }[] = [];

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


  loadAllCharts() {
    this._processedDataService.chartFundingByYearGet(this.fromYear, this.toYear).subscribe(data => this.fundingByYear = data);
    this._processedDataService.chartFundingByCantonGet(this.fromYear, this.toYear).subscribe(data => this.fundingByCanton = data);
    this._processedDataService.chartStartupsByIndustryGet(this.fromYear, this.toYear).subscribe(data => this.startupsByIndustry = this.pivotIndustryData(data));
  }

  formatYearLabel = (arg: any) => {
    return arg.value.toString();
  };

  pivotIndustryData(data: any[]): any[] {
    const grouped: any = {};
    const seriesSet = new Set<string>();

    for (const item of data) {
      const year = item.year;
      if (!grouped[year]) grouped[year] = { year };
      grouped[year][item.industry] = item.count;
      seriesSet.add(item.industry);
    }

    this.industrySeries = Array.from(seriesSet).map(name => ({ name, valueField: name }));
    return Object.values(grouped);
  }

  ngOnInit() {
  }

  title = 'innosuisse.startupticker.webapp.client';
}
