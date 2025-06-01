import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ReceitaService } from '../services/receita.service';
import { Ingrediente } from '../models/ingrediente.model';
import { Receita } from '../models/receita.model';

@Component({
  selector: 'app-criar-receita',
  templateUrl: './criar-receita.component.html',
  styleUrls: ['./criar-receita.component.css']
})
export class CriarReceitaComponent implements OnInit {
  receitaForm!: FormGroup;
  sucesso = false;
  erro = false;

  constructor(
    private fb: FormBuilder,
    private receitaService: ReceitaService
  ) { }

  ngOnInit(): void {
    this.receitaForm = this.fb.group({
      titulo: ['', Validators.required],
      descricao: ['', Validators.required],
      categoria: ['', Validators.required],
      dificuldade: [1, Validators.required], // coloque um default
      duracaoMinutos: [0, Validators.required],
      ingredientes: this.fb.array([])
    });
  }

  get ingredientes(): FormArray {
    return this.receitaForm.get('ingredientes') as FormArray;
  }

  adicionarIngrediente(): void {
    const ingredienteGroup = this.fb.group({
      nome: ['', Validators.required],
      quantidade: [0, [Validators.required, Validators.min(1)]],
      unidade: ['', Validators.required]
    });

    this.ingredientes.push(ingredienteGroup);
  }

  removerIngrediente(index: number): void {
    this.ingredientes.removeAt(index);
  }

  criarReceita(): void {
    if (this.receitaForm.valid) {
      const formValue = this.receitaForm.value;

      const receita: Receita = {
        titulo: formValue.titulo,
        descricao: formValue.descricao,
        categoria: formValue.categoria,
        dificuldade: formValue.dificuldade,
        duracaoMinutos: formValue.duracaoMinutos,
        ingredientes: formValue.ingredientes
      };

      this.receitaService.criarReceita(receita).subscribe({
        next: () => {
          this.sucesso = true;
          this.erro = false;
          this.receitaForm.reset();
          this.ingredientes.clear();
          console.log("Receita criada com sucesso.");
        },
        error: (err) => {
          this.erro = true;
          this.sucesso = false;
          console.error("Erro ao criar receita:", err);
        }
      });
    } else {
      console.warn("Formulário inválido:", this.receitaForm.value);
    }
  }

}
