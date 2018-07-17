import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';



@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        { provide: 'API_URL', useFactory: getApiUrl },
        { provide: 'COMPANY', useFactory: getCompany }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}

export function getApiUrl() {
    return (window as any).config.apiUrl;
}

export function getCompany() {
    return (window as any).config.company;
}
