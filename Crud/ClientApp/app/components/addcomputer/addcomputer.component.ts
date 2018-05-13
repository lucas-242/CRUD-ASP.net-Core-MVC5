import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchComputerComponent } from '../fetchcomputer/fetchcomputer.component';
import { ComputerService } from '../../services/comservice.service';

@Component({
    selector: 'createcomputer',
    templateUrl: './addcomputer.component.html'
})

export class createcomputer implements OnInit {

    computerForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _computerService: ComputerService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.computerForm = this._fb.group({
            id: 0,
            brand: ['', [Validators.required]],
            model: ['', [Validators.required]],
            motherBoard: ['', [Validators.required]],
            ram: ['', [Validators.required]],
            hd: ['', [Validators.required]],
            cpu: ['', [Validators.required]],
            image: ['', [Validators.required]],
        })

    }

    ngOnInit() {

        if (this.id > 0) {
            this.title = "Edit";
            this._computerService.getComputerById(this.id)
                .subscribe(resp => this.computerForm.setValue(resp)
                , error => this.errorMessage = error);
        }

    }

    save() {

        if (!this.computerForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._computerService.saveComputer(this.computerForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-computer']);
                }, error => this.errorMessage = error)
        }

        else if (this.title == "Edit") {
            this._computerService.updateComputer(this.computerForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-computer']);
                }, error => this.errorMessage = error)
        }

    }

    cancel() {
        this._router.navigate(['/fetch-computer']);
    }

    get brand() { return this.computerForm.get('brand'); }
    get model() { return this.computerForm.get('model'); }
    get motherBoard() { return this.computerForm.get('motherBoard'); }
    get ram() { return this.computerForm.get('ram'); }
    get hd() { return this.computerForm.get('hd'); }
    get cpu() { return this.computerForm.get('cpu'); }
    get image() { return this.computerForm.get('image'); }

}