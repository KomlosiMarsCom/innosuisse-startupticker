import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { config } from 'devextreme-angular/common';
import { environment } from './environment/environment';

config({
  licenseKey: `${environment.devExpressLicenceKey}`
});


platformBrowserDynamic().bootstrapModule(AppModule, {
  ngZoneEventCoalescing: true
})
  .catch(err => console.error(err));
