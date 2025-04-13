import { Component, Input } from '@angular/core';
import { ProcessedDataService, StartupFundingRound } from '../../../../typescript-client';

@Component({
  selector: 'app-detail-view',
  templateUrl: './detail-view.component.html',
  styleUrl: './detail-view.component.css'
})
export class DetailViewComponent {

  @Input() id!: string;
  items: StartupFundingRound[] = [];
  dateFormat: string = "dd/MM/yyyy";

  constructor(private readonly _processedDataService: ProcessedDataService) {

  }

  ngOnInit() {
    this._processedDataService.fundingRoundGet(this.id).subscribe(items => {
      this.items = items;
    })

  }
}
