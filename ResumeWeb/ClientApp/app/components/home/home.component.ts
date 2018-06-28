import { Component, Inject } from '@angular/core';
import { ApiService } from '../../api';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    providers: [ApiService]
})
export class HomeComponent {
    private cvData: JSON;

    constructor(private api: ApiService, @Inject("COMPANY") private company: string) {
        if (this.company != null) {
            this.api.GetCoverData().subscribe(result => {
                this.cvData = result.json();
                
            });
        }
    }
}
