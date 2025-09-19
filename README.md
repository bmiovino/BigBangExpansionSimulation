# Big Bang Expansion Simulation Algorithm

## Overview

This repository implements a computational simulation of cosmic expansion inspired by the Big Bang theory. The algorithm models the spatial and energetic evolution of the universe through discrete time steps, using a cellular automaton-like approach where regions of space subdivide and evolve according to a mathematical expansion kernel.

## Core Algorithm

### 1. Initialization

The simulation begins with a single `Region` at the origin:
- **Initial Position**: Coordinate (0, 0)
- **Initial Energy**: 0.0
- **Initial Universe**: Contains one region representing the primordial singularity

```csharp
Region R = new Region(0.0F, new Coordinate(0, 0));
Region[] universe = { R };
```

### 2. Temporal Evolution Loop

The universe evolves through discrete time steps (ages), with each step representing a unit of cosmic time:

```csharp
for (int age = 0; age <= maxage; age++)
{
    if (age > 0)
    {
        // Expansion occurs for age > 0
        List<Region> expansion = new List<Region>();
        foreach (Region r in universe)
            expansion.AddRange(r.Expand(epk));
        universe = expansion.ToArray();
    }
}
```

### 3. Spatial Expansion Mechanism

Each region undergoes **quadratic subdivision** during expansion:

#### Expansion Process:
- Every existing region splits into **4 child regions** arranged in a 2×2 grid
- Child coordinates are calculated using: `(i + parent.X * 2, j + parent.Y * 2)`
- This creates a fractal-like structure where the universe doubles in linear dimension each time step

#### Coordinate Mapping:
```
Parent at (x, y) → Children at:
- (2x, 2y)     - (2x+1, 2y)
- (2x, 2y+1)   - (2x+1, 2y+1)
```

### 4. Energy Distribution Model

Each new region's energy is calculated using a stochastic process:

#### Energy Calculation Formula:
```csharp
double r = (2 * (rand.NextDouble() - 0.5F));  // Random value in [-1, 1]
double newEnergy = epk.Clip(epk.EnergyPdf(r) + parentEnergy);
```

#### Parabolic Kernel Function:
The `ParabolicKernel` implements the energy probability density function:

```csharp
public double EnergyPdf(double r)
{
    if (Math.Abs(r) > Delta)
        return 0;
    
    return ((0.75F / Delta) * (r - (Math.Pow(r, 3) / (3.0F * Math.Pow(Delta, 2))))) + 0.5F;
}
```

This function:
- Has support only within `[-Delta, Delta]`
- Provides a smooth probability distribution for energy fluctuations
- The `0.5F` offset ensures positive baseline energy contribution
- Creates a parabolic-shaped distribution that models quantum fluctuations

### 5. Mathematical Properties

#### Growth Rate:
- **Regions per age**: `4^age` (exponential growth)
- **Spatial dimensions**: `2^age × 2^age` grid
- **Total energy**: Accumulates through inheritance + random fluctuations

#### Energy Conservation:
- Base energy is inherited from parent regions
- Random fluctuations are added via the kernel function
- Optional clipping can constrain energy values to `[-1, 1]`

## System Components

### Core Classes

1. **Region**: Represents a spatial cell with position and energy
2. **IExpansionKernel**: Interface defining energy distribution rules
3. **ParabolicKernel**: Implements parabolic energy probability distribution
4. **Universe**: Provides energy normalization utilities
5. **RenderEngine**: Visualizes the final state as a grayscale image
6. **Coordinate**: Simple 2D position structure

### Algorithm Flow

```
1. Initialize universe with single region at origin
2. For each time step (age):
   a. If age > 0:
      - Each region expands into 4 child regions
      - Child positions calculated via coordinate doubling
      - Child energies computed using stochastic kernel
   b. Log current age and region count
3. Normalize final energy distribution
4. Render visualization to PNG file
```

## Physical Interpretation

This simulation models several aspects of cosmological expansion:

- **Inflation**: The quadratic subdivision represents rapid spatial expansion
- **Quantum Fluctuations**: Random energy variations simulate primordial density fluctuations
- **Spatial Homogeneity**: The regular grid structure maintains spatial isotropy
- **Energy Density Evolution**: Energy inheritance models matter/energy conservation

## Parameters

- **Max Age**: Controls simulation duration (limited to 11 for computational feasibility)
- **Delta**: Controls the width of energy fluctuation distribution (0.0 to 1.0)
- **Clipping**: Optional constraint to limit energy values

## Output

The simulation produces:
1. **Console Output**: Age progression and status updates
2. **PNG Visualization**: Grayscale image where pixel intensity represents normalized energy density

## Computational Complexity

- **Time Complexity**: O(4^n) where n is the maximum age
- **Space Complexity**: O(4^n) for storing all regions
- **Practical Limit**: Age 11 results in ~4 million regions

This algorithm effectively demonstrates how simple rules can generate complex emergent structures reminiscent of cosmic large-scale structure formation.