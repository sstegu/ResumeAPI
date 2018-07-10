import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ResumeComponent } from './components/resume/resume.component';
import { SplitStringPipe } from './components/resume/splitStringPipe';
import { Globals } from './globals';
import { WaitComponent } from './components/wait/wait.component';
import 'rxjs-compat';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ResumeComponent,
        WaitComponent,
        SplitStringPipe
    ],
    providers: [Globals],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'resume', component: ResumeComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        NgbModule.forRoot()

    ]
})
export class AppModuleShared {
}
