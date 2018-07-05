import { Component, Inject } from '@angular/core';
import { ApiService } from '../../api';
import { Globals } from '../../globals';
import { ChangeDetectorRef } from '@angular/core';

@Component({
    selector: 'home',
    styleUrls: ['../../css/common.css', './home.component.css'],
    templateUrl: './home.component.html',
    providers: [ApiService]
})
export class HomeComponent {
    private cvData: JSON;
    private company: string = "";
    private firstName: string = "";
    private lastName: string = "";

    constructor(private api: ApiService, private globals: Globals) {
        Promise.resolve(null).then(() => { this.globals.waiting$.next(true) })
            .then(() => {
                this.company = "";
                if (this.globals.companyGuid != null && this.globals.companyGuid.trim().length > 0) {
                    this.company = this.globals.companyGuid;
                    this.firstName = this.globals.firstName;
                    this.lastName = this.globals.lastName;
                }
                this.getCoverData();
            }).then(() => this.globals.waiting$.next(false));


    }

    private getCoverData(): void {

        if (this.company != null && this.company.trim().length != 0) {
            Promise.resolve(null).then(() => { this.globals.waiting$.next(true) })
                .then(() => {
                    this.api.GetCoverData(this.company).subscribe(result => {
                        if (result.ok) {
                            this.cvData = result.json();
                            //save global
                            this.globals.companyGuid = this.company;
                            this.globals.firstName = this.firstName;
                            this.globals.lastName = this.lastName;

                        }
                    });
                })
                .then(() => {
                    this.globals.waiting$.next(false);
                });
        }

    }

}
