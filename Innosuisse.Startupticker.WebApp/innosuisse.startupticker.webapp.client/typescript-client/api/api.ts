export * from './dataFetchAndEnrich.service';
import { DataFetchAndEnrichService } from './dataFetchAndEnrich.service';
export * from './processedData.service';
import { ProcessedDataService } from './processedData.service';
export * from './rawData.service';
import { RawDataService } from './rawData.service';
export const APIS = [DataFetchAndEnrichService, ProcessedDataService, RawDataService];
