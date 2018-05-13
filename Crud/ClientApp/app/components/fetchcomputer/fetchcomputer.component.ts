import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ComputerService } from '../../services/comservice.service'



@Component({

    selector: 'fetchcomputer',
    templateUrl: './fetchcomputer.component.html',
    styleUrls: ['./fetchcomputer.component.css']

})

export class FetchComputerComponent {

    public comList: ComputerData[];

    constructor(public http: Http, private _router: Router, private _computerService: ComputerService) {
        this.getComputer();
    }

    getComputer() {

        this._computerService.getComputer().subscribe(
            data => this.comList = data

        )

    }

    delete(computerId) {

        var ans = confirm("Do you want to delete computer with Id: " + computerId);

        if (ans) {

            this._computerService.deleteComputer(computerId).subscribe((data) => {
                this.getComputer();
            }, error => console.error(error))

        }

    }

}

interface ComputerData {

    id: number;
    brand: string;
    model: string;
    motherBoard: string;
    ram: string;
    hd: string;
    cpu: number;
    image: string;

}